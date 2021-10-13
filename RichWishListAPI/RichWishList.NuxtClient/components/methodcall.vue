<template>
    <div class="methodcall grid grid-cols-3" :class="method">
        <div>
            <span class="method" :class="method">{{ method }}</span>            
        </div>
        <div>{{ url }}</div>
        <div>{{ method }}</div>
    </div>    
</template>

<script>
export default {
    props: {
        baseurl: String,
        url: String,
        method: String
    }
}
</script>

<style scoped>
  .methodcall {
    font-weight: bold;
    border-radius: 5px;
    padding: .5em;
    margin-block: 1em;    
    border-width: 1px;
    border-style: solid;
  }

  .method {
      text-transform: uppercase;      
      padding-inline: 1em;
      color: white;
  }

  .method.get {
      background-color: #61AFFE;
      color: white;      
  }
  .method.post {
      background-color: #49CC90;
      color: white;      
  }
  .method.put {
      background-color: #FCA130;
      color: white;      
  }
  .method.delete {
      background-color: #F93E3E;
      color: white;      
  }  

  .get {
    color: #61AFFE;
    border-color: #61AFFE;
    background-color: #EBF3FB;
  }

  .put {
    color: #FCA130;
    border-color: #FCA130;
    background-color: #FBF1E6;
  }

  .post {
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