<template>
<div class="text-center">
<v-card-text>
      <p class="text-h4 text--primary">
        Nova Movimentação de estoque
      </p>
    </v-card-text>

  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
   
      <v-select
      v-model="movimentacao.empPesID"
      :items="nomeEmpresa"
      :rules="[v => !!v || 'Item is required']"
      :disabled="!validandoCampos"
      label="Selecione o Cliente / Fornecedor"
      @change="selecionadoClienteFornecedor.type = $event"
      required
    ></v-select>

    <v-text-field
      v-model="preco"
      :rules="valorTotalRules"
      :disabled = true
      label="Valor Total"
      type="number"
      required
    ></v-text-field>

    <v-select
      v-model="movimentacao.entradaSaida" 
      :items="itemsEntSai"
      :rules="EntSaiRules"
      :disabled="!validandoCampos"
      label="Entrada ou Saída"
      @change="selecionadoEntradaSaida.type = $event"
      required
    ></v-select>

    <v-select
      v-model="inputIdProduto" 
      :items="produtos"
      :rules="prodRules"
      item-value="produtoID"
      item-text="descricaoProduto"
      label="Produtos"
      required
    ></v-select>

    <v-text-field
      v-model="inputQuantidade"
      :rules="quantidadeRules"
      label="Quantidade unitário"
      type="number"
      required
    ></v-text-field>

    <v-text-field
      v-model="inputValor"
      :rules="valorRules"
      label="Valor unitário"
      type="number"
      required
    ></v-text-field>

     <v-btn
      color="success"
      class="mr-4"
      @click="adicionarItem($event)"
    >
      Adicionar Item
    </v-btn>
    <br> <br> 
      <v-data-table
        :headers="headers"
        :items="listaProduto"
        :items-per-page="5"
        class="elevation-1"
    ></v-data-table>

    <v-btn
      color="success"
      class="mr-4"
      @click="validate"
    >
      Salvar
    </v-btn>

    <v-btn
      color="warning"
      @click="resetValidation"
    >
      Voltar
    </v-btn>
  </v-form>

</div>  
</template>

<script>
  export default {

    data: () => ({
      validandoCampos: true,
      emppes: [],
      inputValor: 0,
      nomeEmpresa: [],
      produtos: [],
      nomeProduto: [],
      inputQuantidade: 0,
      inputIdProduto: 0,
      listaProduto: [],
      listaProdutoEnviar: [],
      itemExibir: {
        produtoID: 0,
        quantidade: 0,
        valor: 0,
        descricaoProduto: ''
      },
      
      movimentacao: {
              empPesID: 0,
              valorTotal: 0,
              entradaSaida: "",
              itemMovEstoques: [
          {
            movEstoqueID: 0,
            sequencia: 0,
            quantidade: 0,
            valorUnitario : 0,
            produtoID : 0
          },
        ]
      },
      valid: true,
      name: '',
      valorRules: [ v => !!v || 'Preço obrigatório'],
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length >= 3) || 'Mínimo de 3 letras',
      ],
      CnpjCpfRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      FisicoJuridicoRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      ProdRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      EntSaiRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      quantidadeRules: [],
      quantidade: '',
      selecionadoClienteFornecedor: {
        type: undefined
      },
      selecionadoEntradaSaida: {
        type: undefined
      },
      select: null,
      selectEntSai: null,
      itemsEntSai: [
        'Entrada',
        'Saída',
      ],
      selectProd: null,
      valorTotalRules: [],
      preco: 0,
      prodRules: [],
      checkbox: false,
      headers: [
         {
            text: 'Id',
            align: 'end',
            sortable: false,
            value: 'produtoID',
          },
          { text: 'Item', align: 'end', value: 'descricaoProduto' },
          { text: 'Quantidade', align: 'end', value: 'quantidade' },
          { text: 'Valor Unitário', align: 'end', value: 'valor' },
          { text: 'Excluir', align: 'end', value: 'protein' },
        ],
        desserts: [
        ],
    }),

    created () {
      this.initialize()
    },

    methods: {
      async initialize () {
        try {
            var response = await this.$axios({
               method: "GET",
               url: 'https://localhost:7009/emppes'
            });
            this.emppes = response.data;
           
            for (const key in this.emppes) {
              this.nomeEmpresa.push(this.emppes[key].nomeEmpPes);
            } 
           
            console.log(this.emppes)
          } catch (error) {
            console.log(error)
          }

          try {
            var response = await this.$axios({
               method: "GET",
               url: 'https://localhost:7009/produto'
            });
            this.produtos = response.data;
           

            for (const key in this.emppes) {
              this.nomeProduto.push(this.produtos[key].descricaoProduto);
            } 
           
            console.log(this.nomeProduto)
          } catch (error) {
            console.log(error)
          }


      },
      adicionarItem () {
        let item = {
        produtoID: 0,
        quantidade: 0,
        valor: 0,
      };

        this.movimentacao.itemMovEstoques[0].quantidade = this.inputQuantidade;  
        this.movimentacao.itemMovEstoques[0].quantidade = this.inputIdProduto;
        this.validandoCampos = false;
        item.produtoID = this.inputIdProduto;
        item.quantidade = this.inputQuantidade;
        item.valor = this.inputValor;
        this.listaProdutoEnviar.push(item)
        console.log('lista produto enviar')
        console.log(this.listaProdutoEnviar)
       
        console.log('willian')
        console.log(item.produtoID)
        console.log(this.produtos.filter( (it) => { return it.produtoID == item.produtoID }))
        let valor = this.produtos.filter( (it) => { return it.produtoID == item.produtoID });
        console.log(valor[0].descricaoProduto)
        this.itemExibir = item;
        console.log("Aqui")
        this.itemExibir.descricaoProduto = valor[0].descricaoProduto;
        console.log("Aqui2")
        this.listaProduto.push(this.itemExibir)
        console.log(this.listaProduto)
        this.movimentacao.empPesID = true;

      },
      reset () {
        this.$refs.form.reset()
      },
      resetValidation () {
        this.$refs.form.resetValidation()
      },
      validate(){

      }
    },
  }
</script>