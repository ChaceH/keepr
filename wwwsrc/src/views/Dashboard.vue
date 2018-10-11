<template>
    <div class="dashboard">
        <navigation-bar/>
        <div class="row" style="margin-top: 75px;">
          <div class="card col-sm-6">
        <h3>Create a Keep</h3>
        <form style="" @submit.prevent="addKeep">
        <input type="text" placeholder="title" v-model="newKeep.name" required>
        <input type="text" placeholder="description" v-model="newKeep.description">
        <input type="url" placeholder="Image Link" v-model="newKeep.img">
        <button class="btn btn-success" type="submit" style="height: 3vh; width: 10vw; color: black;">Post Keep</button>
      </form>
      </div>
        <div class="card col-sm-6">
        <h3>Create a Vault</h3>
        <form style="" @submit.prevent="addVault">
        <input type="text" placeholder="title" v-model="newVault.name" required>
        <input type="text" placeholder="description" v-model="newVault.description">
        <button class="btn btn-success" type="submit" style="height: 3vh; width: 10vw; color: black;">Create Vault</button>
      </form>
      </div>
      </div>
      <div class="row" style="margin-top: 75px;">
      <div class="col-sm-4" v-for="vault in vaults" :key="vault._id" >
        <!-- keep component here -->
        <vault :vaultData='vault' />
      </div>
    </div>
    </div>
</template>

<script>
import NavigationBar from "@/components/Navbar.vue";
import vault from "@/components/Vault.vue";
import keep from "@/components/Keep.vue";

export default {
  name: "dashboard",
  components: {
    keep,
    vault,
    NavigationBar
  },
  mounted() {
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
    this.$store.dispatch("getVaultsByUserId", this.$store.state.user.id);
  },
  data() {
    return {
      newKeep: {
        img: "",
        name: "",
        description: ""
      },
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
      this.newKeep = { img: "", name: "", description: "" };
    },
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      this.newVault = { name: "", description: "" };
    },
    logout() {
      this.$store.dispatch("logout", this.login);
    }
  }
};
</script>

<style>
</style>
