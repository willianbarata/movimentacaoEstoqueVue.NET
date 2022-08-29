<template>
<div class="text-center">
<v-card-text>
      <p class="text-h4 text--primary">
        Editar Empresa ou Pessoa Física
      </p>
    </v-card-text>

  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="EmpPes.nomeEmpPes"
      :counter="10"
      :rules="NomeEmpPesRules"
      label="Nome Pessoa Física ou Jurídica"
      required
    ></v-text-field>

    <v-select
    v-model="EmpPes.clienteFornecedor"
    :items="itemClienteFornecedor"
    :rules="[v => !!v || 'Item is required']"
    label="Cliente / Fornecedor"
    @change="selecionadoClienteFornecedor.type = $event"
    required
  ></v-select>

  <v-select
    v-model="EmpPes.fisicoJuridico"
    :items="itemFisicoJuridico"
    :rules="[v => !!v || 'Item is required']"
    label="Físico / Jurídico"
    @change="selecionadoFisicoJuridico.type = $event"
    required
  ></v-select>

    <v-text-field
      v-model="EmpPes.cnpjCpf"
      :counter="10"
      :rules="CnpjCpfRules"
      label="Cnpj / Cpf"
      required
    ></v-text-field>

    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="editarEmpPes"
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
  <pre>
    {{EmpPes}}
  </pre>
</div>  
</template>

<script>
  export default {
    data: () => ({

      EmpPes:{
        nomeEmpPes: '',
        clienteFornecedor: '',
        cnpjCpf: '',
        fisicoJuridico: '',
      },
      selecionadoClienteFornecedor: {
        type: undefined
      },
      selecionadoFisicoJuridico: {
        type: undefined
      },
      itemClienteFornecedor: [
        'Cliente',
        'Fornecedor'
      ],
      itemFisicoJuridico: [
        'Físico',
        'Jurídico'
      ],  
      valid: true,
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
      checkbox: false,
      
    }),
    created () {
      this.initialize()
    },

    methods: {
       async initialize () {
        var id = this.$route.params.EditarEmpPes;
        console.log("id")
        console.log(id)
        try {
            var response = await this.$axios({
               method: "GET",
               url: `https://localhost:7009/emppes/${id}`
            });
            this.EmpPes = response.data;
            console.log(this.EmpPes)
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
      resetValidation () {
        this.$refs.form.resetValidation()
      },
      voltarEmpPes () {
        this.$router.push('/emppes')
      },
      async editarEmpPes(){
         try {
          this.EmpPes.ClienteFornecedor = this.selecionadoClienteFornecedor.type;
          this.EmpPes.FisicoJuridico = this.selecionadoFisicoJuridico.type;
            var response = await this.$axios({
               method: "PUT",
               url: 'https://localhost:7009/emppes',
               data: this.EmpPes
            });
            this.$router.push('/emppes')
          } catch (error) {
            console.log(error)
          }
      }
    },
  }
</script>