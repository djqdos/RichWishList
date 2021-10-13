<template>
    <div>
        <div class="wishlistitem grid grid-cols-3">
            <div class="itemname">{{ itemName }}</div>
            <div class="quantity">{{ quantity }}</div>
            <div class="buttons">
                <button @click="increase(id)" class="increase">+</button>
                <button @click="decrease(id)" class="decrease">-</button>
                <button @click="deleteItem(id)" class="ml-4 delete">x</button>                
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        itemName: String,
        quantity: Number,
        id: String
    },

    methods: {
        increase(itemId) {
            this.$nuxt.$emit("increase", itemId);
        },

        decrease(itemId) {
            this.$nuxt.$emit("decrease", itemId);
        },

        deleteItem(itemId) {
            this.$nuxt.$emit("deleteItem", itemId);
        }
    }
}
</script>

<style scoped>

.wishlistitem {
    border: 1px solid black;
    border-radius: 5px;
    padding: .5em;
    margin-block: 1em;
}


.increase, .decrease, .delete {    
    border-radius: 5px;
    padding-inline: .5em;    
    font-weight: bold;
}

.increase {
    border: 1px solid green;
    color: #49CC90;
    border-color: #49CC90;
    background-color: #E8F6F0;    
}

.decrease {
    border: 1px solid green;
    color: #49CC90;
    border-color: #49CC90;
    background-color: #E8F6F0;    
}

.delete {
    color: #F93E3E;
    border-color: #F93E3E;
    background-color: #FAE7E7;
}

</style>
