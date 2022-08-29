<template>
<div class="text-center">
<v-card-text>
      <p class="text-h4 text--primary">
        Editar Movimentação de estoque
      </p>
    </v-card-text>

  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
   
      <v-select
      v-model="select"
      :items="items"
      :rules="[v => !!v || 'Item is required']"
      label="Selecione o Cliente / Fornecedor"
      required
    ></v-select>

    <v-text-field
      v-model="preco"
      :rules="valorTotalRules"
      disabled="true"
      label="Valor Total"
      type="number"
      required
    ></v-text-field>

    <v-select
      v-model="selectEntSai" 
      :items="itemsEntSai"
      :rules="EntSaiRules"
      label="Entrada ou Saída"
      required
    ></v-select>

    <v-select
      v-model="selectProd" 
      :items="itemsProd"
      :rules="prodRules"
      label="Produtos"
      required
    ></v-select>

    <v-text-field
      v-model="quantidade"
      :rules="quantidadeRules"
      label="Quantidade unitário"
      type="number"
      required
    ></v-text-field>

     <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="validate"
    >
      Adicionar Item
    </v-btn>

      <v-data-table
        :headers="headers"
        :items="desserts"
        :items-per-page="5"
        class="elevation-1"
    ></v-data-table>


    <v-btn
      :disabled="!valid"
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
      valid: true,
      name: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length >= 3) || 'Mínimo de 3 letras',
      ],
      email: '',
        ClienteFornecedorRules: [
        v => !!v || 'Preço obrigatório',
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
      select: null,
      items: [
        'Item 1',
        'Item 2',
        'Item 3',
        'Item 4',
      ],
      selectEntSai: null,
      itemsEntSai: [
        'Entrada',
        'Saída',
      ],
      selectProd: null,
      itemsProd: [
        'Entrada',
        'Saída',
      ],
      checkbox: false,
      headers: [
          {
            text: 'Id',
            align: 'end',
            sortable: false,
            value: 'name',
          },
          { text: 'Item', align: 'end', value: 'calories' },
          { text: 'Sequência', align: 'end', value: 'calories' },
          { text: 'Quantidade', align: 'end', value: 'fat' },
          { text: 'Valor Unitário', align: 'end', value: 'carbs' },
          { text: 'Excluir', align: 'end', value: 'protein' },
        ],
        desserts: [
          {
            name: 'Frozen Yogurt',
            calories: 159,
            fat: 6.0,
            carbs: 24,
            protein: 4.0,
            iron: '1%',
          },
          {
            name: 'Ice cream sandwich',
            calories: 237,
            fat: 9.0,
            carbs: 37,
            protein: 4.3,
            iron: '1%',
          },
          {
            name: 'Eclair',
            calories: 262,
            fat: 16.0,
            carbs: 23,
            protein: 6.0,
            iron: '7%',
          },
          {
            name: 'Cupcake',
            calories: 305,
            fat: 3.7,
            carbs: 67,
            protein: 4.3,
            iron: '8%',
          },
          {
            name: 'Gingerbread',
            calories: 356,
            fat: 16.0,
            carbs: 49,
            protein: 3.9,
            iron: '16%',
          },
          {
            name: 'Jelly bean',
            calories: 375,
            fat: 0.0,
            carbs: 94,
            protein: 0.0,
            iron: '0%',
          },
          {
            name: 'Lollipop',
            calories: 392,
            fat: 0.2,
            carbs: 98,
            protein: 0,
            iron: '2%',
          },
          {
            name: 'Honeycomb',
            calories: 408,
            fat: 3.2,
            carbs: 87,
            protein: 6.5,
            iron: '45%',
          },
          {
            name: 'Donut',
            calories: 452,
            fat: 25.0,
            carbs: 51,
            protein: 4.9,
            iron: '22%',
          },
          {
            name: 'KitKat',
            calories: 518,
            fat: 26.0,
            carbs: 65,
            protein: 7,
            iron: '6%',
          },
        ],
    }),

    methods: {
      validate () {
        this.$refs.form.validate()
      },
      reset () {
        this.$refs.form.reset()
      },
      resetValidation () {
        this.$refs.form.resetValidation()
      },
    },
  }
</script>