<template>
    <div class="vault card" style="box-shadow: 3px 3px 3px black; margin-bottom: 2rem;">
        <button class="btn" @click="deleteVault()" style="background-color: transparent; height: 3vh; width: 2vw;"><i class="fa fa-trash"></i></button>
        <h2>{{vaultData.name}}</h2>
        <p>{{vaultData.description}}</p>
        <button class="btn btn-primary">Open Vault</button>
    </div>
</template>

<script>
export default {
     name: "vault",
     props: ["vaultData"],
     mounted() {
    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
  },
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData.id);
    },
  }
};
</script>

<style scoped>

</style>
