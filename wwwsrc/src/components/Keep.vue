<template>
<div class="keep card"  @click="view()" style="box-shadow: 3px 3px black; margin-bottom: 2rem;">
    <button class="btn"><i class="far fa-edit"></i></button>
    <button class="btn" @click="deleteKeep()"><i class="fa fa-trash"></i></button>
    <img :src="keepData.img" alt="">
    <h3 style="">{{keepData.name}}</h3>
    <p style="">{{keepData.description}}</p>
    <p class="btn"><i class="far fa-eye">:{{keepData.views}}</i></p>
    <button class="btn" @click="share()"><i class="fas fa-share-square">:{{keepData.shares}}</i></button>
    <button class="btn" @click="save()"><i class="far fa-save">:{{keepData.keeps}}</i></button>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"],
  mounted() {
    //blocks users not logged in
    // if (!this.$store.state.user.id) {
    //   this.$router.push({ name: "login" });
    // }
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepData.id);
    },
    view() {
      this.$store.dispatch("addKeepView", this.keepData.id);
    },
    share() {
      this.$store.dispatch("addKeepShare", this.keepData.id);
    },
    save(vaultId){
      this.$store.dispatch("addKeepToVault", {keepId: this.keepData.id, vaultId: vaultId});
    },
    showAvailableVaults(){
      
    }
  }
};
</script>

<style scoped>
.btn {
  background-color: transparent;
  height: 3vh;
  width: 2vw;
}
</style>
