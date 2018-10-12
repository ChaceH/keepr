<template>
  <div class="home container-fluid">
    <navigation-bar/>
      <div class="row" style="margin-top: 75px;">
      <div class="col-sm-4" v-for="keep in keeps" :key="keep.id" >
        <!-- keep component here -->
        <keep :keepData="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import NavigationBar from "@/components/Navbar.vue";
import keep from "@/components/Keep.vue";

export default {
  name: "home",
  props: ["browsing"],
  components: {
    keep,
    NavigationBar
  },
  mounted() {
    //blocks users not logged in
    if (this.browsing) {
      this.$router.dispatch("getKeeps");
    }
    this.$store.dispatch("authenticate");
    this.$store.dispatch("getKeeps");
  },
  data() {
    return {
      newKeep: {
        img: "",
        name: "",
        description: ""
      }
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
      this.newKeep = { img: "", name: "", description: "" };
    },
    logout() {
      this.$store.dispatch("logout", this.login);
    }
  }
};
</script>

<style>
</style>