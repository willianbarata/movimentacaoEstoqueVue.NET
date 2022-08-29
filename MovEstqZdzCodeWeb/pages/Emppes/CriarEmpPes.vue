<template>
<div class="text-center">
<v-card-text>
      <p class="text-h4 text--primary">
        Cadastrar Empresa ou Pessoa Física
      </p>
    </v-card-text>

  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="EmpPes.NomeEmpPes"
      :counter="10"
      :rules="NomeEmpPesRules"
      label="Nome Pessoa Física ou Jurídica"
      required
    ></v-text-field>

    <v-select
      v-model="EmpPes.ClienteFornecedor"
      :items="itemClienteFornecedor"
      :rules="[v => !!v || 'Item is required']"
      label="Cliente / Fornecedor"
      @change="selecionadoClienteFornecedor.type = $event"
      required
    ></v-select>

    <v-select
      v-model="EmpPes.FisicoJuridico"
      :items="itemFisicoJuridico"
      :rules="[v => !!v || 'Item is required']"
      label="Físico / Jurídico"
      @change="selecionadoFisicoJuridico.type = $event"
      required
    ></v-select>

    <v-text-field
      v-model="EmpPes.CnpjCpf"
      :counter="10"
      :rules="CnpjCpfRules"
      label="Cnpj / Cpf"
      required
    ></v-text-field>

    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="salvarEmpPes"
    >
      Salvar
    </v-btn>

    <v-btn
      color="warning"
      @click="voltarEmpPes"
    >
      Voltar
    </v-btn>
  </v-form>
</div>  
</template>

<script>
  export default {
    data: () => ({
      valid: true,
      EmpPes:{
        NomeEmpPes: '',
        ClienteFornecedor: '',
        CnpjCpf: '',
        FisicoJuridico: '',
      },
      selecionadoClienteFornecedor: {
        type: undefined
      },
      selecionadoFisicoJuridico: {
        type: undefined
      },
      NomeEmpPesRules: [
        v => !!v || 'Name is required',
        v => (v && v.length >= 3) || 'Mínimo de 3 letras',
      ],
      
        ClienteFornecedorRules: [
        v => !!v || 'Preço obrigatório',
      ],
      
      CnpjCpfRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      
      FisicoJuridicoRules: [
        v => !!v || 'Quantidade obrigatório, pode utilizar zero (0)',
      ],
      select: null,
      items: [
        'Item 1',
        'Item 2',
        'Item 3',
        'Item 4',
      ],
      itemClienteFornecedor: [
        'Cliente',
        'Fornecedor'
      ],
      itemFisicoJuridico: [
        'Físico',
        'Jurídico'
      ],  
      checkbox: false,
    }),

    methods: {
      validate () {
        this.$refs.form.validate()
      },
      reset () {
        this.$refs.form.reset()
      },
      voltarEmpPes () {
        this.$router.push('/emppes')
      },
      async salvarEmpPes(){
        this.EmpPes.ClienteFornecedor = this.selecionadoClienteFornecedor.type;
        this.EmpPes.FisicoJuridico = this.selecionadoFisicoJuridico.type;
        console.log(this.selecionadoClienteFornecedor.type);
        console.log(this.EmpPes.ClienteFornecedor);
        try {
            var response = await this.$axios({
               method: "POST",
               url: 'https://localhost:7009/emppes',
               data: this.EmpPes
            });
            console.log(response)
            this.$router.push('/EmpPes')
          } catch (error) {
            console.log(error)
          }
      }
    },
  }
</script>