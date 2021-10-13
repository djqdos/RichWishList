<template>
  <div class="">    

    <h1>RichWishList</h1>

    <input type="text" ref="itemname" placeholder="Item Name" />
    <input type="number" ref="quantity" min="0" placeholder="Quantity" />
    <button @click="addNewItem" id="newitem">Add New Item</button>
    <button @click="getItems" id="getitems">Get Items</button>

    <div class="grid grid-cols-2 gap-2">
      <div>
      <wishlistitem v-for="item in ItemList" :key="item.id" 
        :itemName="item.itemName"  
        :quantity="item.quantity"
        :id="item.id"
        />
      </div>

        

      <div>
        <methodcall v-for="(item, index) in MethodHistory" :key="index" 
          :baseurl="item.baseURL"
          :url="item.url"
          :method="item.method"
        />
      </div>
    </div>

  </div>
</template>

<script>
import { uuid } from 'vue-uuid';
import wishlistitem from '~/components/wishlistitem.vue';
import methodcall from '~/components/methodcall.vue';

export default {
  components: { wishlistitem, methodcall },
  data() {
    return {
      ItemList: [],
      MethodHistory: []      
    }
  },


  // Fires when the component is mounted and ready to go
  async mounted() {

    // Intercept Request calls, to add to list
    this.$axios.interceptors.request.use((request) => {        
        this.MethodHistory.push(request);
        return request;
    });


    // Listen for the "increase" event emitted from child component
    this.$nuxt.$on("increase", (itemId) => {
      console.log("fired from child");
      this.increase(itemId)
    });

    // Listen for the "decrease" event emitted from child component
    this.$nuxt.$on("decrease", (itemId) => {
      console.log("fired from child");
      this.decrease(itemId)
    });    

    // Listen for the "deleteItem" event emitted from child component
    this.$nuxt.$on("deleteItem", (itemId) => {
      console.log("fired from child");
      this.deleteItem(itemId)
    });   

    // Get Initial list of Items on page load/component mounted
    try {
      const response = await this.$axios.get("/WishList");
      this.ItemList = response.data;
    }
    catch (err) {
      console.log(err);
    }

  },

  methods: {    
    async addNewItem() {      
      var newItem = {
        id: uuid.v1(),
        itemName: this.$refs.itemname.value,
        quantity: this.$refs.quantity.value
      };

      try {
        let postResponse = await this.$axios.post('/WishList', newItem);
        await this.getItems();
      }
      catch (err) {
        console.log("Err = ", err);
      }
    },

    async getItems() {
      const response = await this.$axios.get("/WishList");
      this.ItemList = response.data;
    },

    async increase(itemId) {
      var itemToUpdate = this.ItemList.filter(item => {
        return item.id == itemId;
      })[0];

      itemToUpdate.quantity = itemToUpdate.quantity+1;
      await this.updateItems(itemToUpdate);
      await this.getItems();
    },

    async decrease(itemId) {
      var itemToUpdate = this.ItemList.filter(item => {
        return item.id == itemId;
      })[0];

      itemToUpdate.quantity = itemToUpdate.quantity-1;
      await this.updateItems(itemToUpdate);
      await this.getItems();
    },


    async updateItems(item) {      
      const response = await this.$axios.put("/WishList", item);
    },

    async deleteItem(itemId) {
      console.log("delete item id = ", itemId);      
      const response = await this.$axios.delete(`/WishList?id=${itemId}`);
      await this.getItems();
    }


  }
  

}
</script>

<style scoped>
  h1 {
    font-size: 3em;
    margin-bottom: .5em;
  }

  input {
    border: 1px solid black;
    padding: .5em;
  }

  button {
    padding: .5em;
    border: 1px solid black;
    border-radius: 5px;
  }

  #newitem {
    background-color: green;
    color: white;
  }

  #getitems {
    background-color: coral;
    color: white;
  }

  .wish-list {
    border-right: 1px solid black;
    margin-right: 1em;
  }

</style>
