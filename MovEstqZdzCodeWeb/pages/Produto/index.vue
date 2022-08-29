<template>
  <v-data-table
    :headers="headers"
    :items="produtos"
    sort-by="calories"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-toolbar-title>Produto</v-toolbar-title>
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
              @click="rotaCriarProduto"
            >
              Novo Produto
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
                      v-model="produtos.descricaoProduto"
                      label="Descrição"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="produtos.valorProduto"
                      label="Preço Produto"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="produtos.quantidade"
                      label="Fat (g)"
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
                cancelar
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
            <v-card-title class="text-h5">Deseja realmente excluir o item</v-card-title>
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

      produtos: [],
        headers: [
          {
            text: 'Id',
            align: 'center',
            sortable: false,
            value: 'produtoID',
          },
          { text: 'Descrição Produto', align: 'center', value: 'descricaoProduto' },
          { text: 'Preço', align: 'center', value: 'valorProduto' },
          { text: 'Quantidade', align: 'center', value: 'quantidade' },
          { text: 'Editar / Excluir', align: 'center', value: 'actions', sortable: false },
        ],	  
      desserts: [],
      editedIndex: 'produtoID',
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
      produtoExcluir: {
        produtoID: 0,
        descricaoProduto: '',
        valorProduto: 0,
        quantidade: 0
      }
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
               url: 'https://localhost:7009/produto'
            });
            this.produtos = response.data;
            console.log(this.emppes)
          } catch (error) {
            console.log(error)
          }
      },

      editItem (item) {
        this.editedIndex = this.produtos.indexOf(item)
        var id = this.produtos[this.editedIndex].produtoID;
        this.$router.push(`/produto/${id}`)
      },

      deleteItem (item) {
        
        this.editedIndex = this.produtos.indexOf(item)
        var id = this.produtos[this.editedIndex].produtoID;
        console.log(id);

        this.produtoExcluir.produtoID = this.produtos[this.editedIndex].produtoID;
        this.produtoExcluir.descricaoProduto = this.produtos[this.editedIndex].descricaoProduto;
        this.produtoExcluir.valorProduto = this.produtos[this.editedIndex].valorProduto;
        this.produtoExcluir.quantidade = this.produtos[this.editedIndex].quantidade;
    
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
      rotaCriarProduto(){
         this.$router.push('/produto/CriarProduto')
        console.log("chegou");
      },
      async excluirItem(){

         try {
            var response = await this.$axios({
               method: "DELETE",
               url: `https://localhost:7009/produto`,
               data: this.produtoExcluir
            });
            this.initialize();
          } catch (error) {
            console.log(error)
          }
      }
    },
  }
</script>