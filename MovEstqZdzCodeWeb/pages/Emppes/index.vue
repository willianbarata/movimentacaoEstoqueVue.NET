<template>
  <v-data-table
    :headers="headers"
    :items="emppes"
    sort-by="calories"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-toolbar-title>Empresa / Pessoa</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
        <v-dialog
          v-model="dialog"
          max-width="500px"
        >
          <template v-slot:activator="{ }">
           
            <v-btn
              color="primary"
              dark
              class="mb-2"
              @click="rotaCriarEmpPes"
            >
              Nova Empresa / Pessoa
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.name"
                      label="Dessert name"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.calories"
                      label="Calories"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.fat"
                      label="Fat (g)"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.carbs"
                      label="Carbs (g)"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.protein"
                      label="Protein (g)"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue darken-1"
                text
                @click="close"
              >
                Cancel
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="save"
              >
                Save
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:item.actions="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      <v-btn
        color="primary"
        @click="initialize"
      >
        Reset
      </v-btn>
    </template>
  </v-data-table>
</template>

<script>
  export default {
    data: () => ({
      dialog: false,
      dialogDelete: false,
      
      headers: [
        {
          text: 'Dessert (100g serving)',
          align: 'start',
          sortable: false,
          value: 'name',
        },
        { text: 'Calories', value: 'calories' },
        { text: 'Fat (g)', value: 'fat' },
        { text: 'Carbs (g)', value: 'carbs' },
        { text: 'Protein (g)', value: 'protein' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],

      emppes: [],
        headers: [
          {
            text: 'Id',
            align: 'center',
            sortable: false,
            value: 'empPesID',
          },
          { text: 'Empresa / Pessoa', align: 'center', value: 'nomeEmpPes' },
          { text: 'Cliente / Fornecedor', align: 'center', value: 'clienteFornecedor' },
          { text: 'Cnpj / Cpf', align: 'center', value: 'cnpjCpf' },
          { text: 'Físico / Jurídico', align: 'center', value: 'fisicoJuridico' },
          { text: 'Editar / Excluir', align: 'center', value: 'actions', sortable: false },
        ],
      desserts: [],
      editedIndex: -1,
      editedItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
      defaultItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
       excluirEmpPes:{
        empPesID: 0,
        nomeEmpPes: '',
        clienteFornecedor: '',
        cnpjCpf: '',
        fisicoJuridico: '',
      },
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
      },
    },

    watch: {
      dialog (val) {
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

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
            console.log(this.emppes)
          } catch (error) {
            console.log(error)
          }
      },

      rotaCriarEmpPes(){
        this.$router.push('/emppes/CriarEmpPes')
        console.log("chegou");
      },
      editItem (item) {
        this.editedIndex = this.emppes.indexOf(item);
        var id = this.emppes[this.editedIndex].empPesID;
        this.$router.push(`/emppes/${id}`);
        console.log(id);
      },

      deleteItem (item) {
        this.editedIndex = this.emppes.indexOf(item)
        
        this.excluirEmpPes.empPesID =  this.emppes[this.editedIndex].empPesID;
        this.excluirEmpPes.nomeEmpPes = this.emppes[this.editedIndex].nomeEmpPes;
        this.excluirEmpPes.clienteFornecedor = this.emppes[this.editedIndex].clienteFornecedor;
        this.excluirEmpPes.cnpjCpf = this.emppes[this.editedIndex].cnpjCpf;
        this.excluirEmpPes.fisicoJuridico = this.emppes[this.editedIndex].fisicoJuridico;

        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.desserts.splice(this.editedIndex, 1)
        this.closeDelete()
        this.excluirItem()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.desserts[this.editedIndex], this.editedItem)
        } else {
          this.desserts.push(this.editedItem)
        }
        this.close()
      },

      async excluirItem(){

         try {
            var response = await this.$axios({
               method: "DELETE",
               url: `https://localhost:7009/emppes`,
               data: this.excluirEmpPes
            });
            this.initialize();
          } catch (error) {
            console.log(error)
          }
      }
    },
  }
</script>