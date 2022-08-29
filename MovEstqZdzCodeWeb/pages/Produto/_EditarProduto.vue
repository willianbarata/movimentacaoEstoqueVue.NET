<template>
<div class="text-center">
<v-card-text>
      <p class="text-h4 text--primary">
        Editar Produto
      </p>
    </v-card-text>

  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="produto.descricaoProduto"
      :counter="10"
      :rules="descricaoProdutoRules"
      label="Descrição"
      required
    ></v-text-field>

    <v-text-field
      v-model="produto.valorProduto"
      :rules="valorProdutoRules"
      label="Preço"
      type="number"
      required
    ></v-text-field>

    <v-text-field
      v-model="produto.quantidade"
      :rules="quantidadeRules"
      label="Quantidade"
      type="number"
      required
    ></v-text-field>

    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="editarProduto"
    >
      Salvar
    </v-btn>

    <v-btn
      color="warning"
      @click="rotaProduto"
    >
      Voltar
    </v-btn>
  </v-form>

  <pre>
    {{this.$route.params}}
  </pre>
</div>  
</template>

<script>
  export default {
    data: () => ({
      valid: true,

      produto : {
        descricaoProduto : '',
        valorProduto : 0,
        quantidade: 0
      },
      descricaoProdutoRules: [
        v => !!v || 'Name is required',
        v => (v && v.length >= 3) || 'Mínimo de 3 letras',
      ],
        valorProdutoRules: [
        v => !!v || 'Preço obrigatório',
      ],
      quantidadeRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      select: null,
      items: [
        'Item 1',
        'Item 2',
        'Item 3',
        'Item 4',
      ],
      checkbox: false,
    }),

    created () {
      this.initialize()
    },


    methods: {
      async initialize () {
        var id = this.$route.params.EditarProduto;
        console.log("id")
        console.log(id)
        try {
            var response = await this.$axios({
               method: "GET",
               url: `https://localhost:7009/produto/${id}`
            });
            this.produto = response.data;
            console.log(this.produto)
          } catch (error) {
            console.log(error)
          }
      },
      validate () {
        this.$refs.form.validate()
      },
      reset () {
        this.$refs.form.reset()
      },
      rotaProduto(){
         this.$router.push('/produto')
      },
      resetValidation () {
        this.$refs.form.resetValidation()
      },
      async editarProduto(){
        try {
            var response = await this.$axios({
               method: "PUT",
               url: 'https://localhost:7009/produto',
               data: this.produto
            });
            console.log(response)
            this.$router.push('/produto')
          } catch (error) {
            console.log(error)
          }
      }
   }
  }
</script>