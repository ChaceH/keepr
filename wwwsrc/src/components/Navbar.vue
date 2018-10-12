<template>
   <v-toolbar fixed dark color="black accent-2">
       <v-btn flat href="#" icon @click="home()"> <!-- route to top of page -->
           <v-icon color="white" large>fas fa-skull</v-icon>
       </v-btn>
       <v-spacer></v-spacer>
           <h1>KEEPR</h1>
       <v-spacer></v-spacer>
       <v-toolbar-items v-if="user.id">
         <h5>Dashboard </h5>
           <v-btn icon @click="dashboard()">
               <v-icon>far fa-user-circle</v-icon>
           </v-btn>
          <h5>Logout</h5>
           <v-btn icon @click="logout()">
               <v-icon>fa-sign-out-alt</v-icon>
           </v-btn>
       </v-toolbar-items>
       <v-toolbar-items v-else>
           <v-layout full-height align-center>
               <v-btn flat round large @click="createAccount()" class="white--text">Login / Create Account</v-btn>
           </v-layout>
       </v-toolbar-items>
   </v-toolbar>
</template>

<script>
export default {
  name: "navigationBar",
  data() {
    return {
      search: ""
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    home() {
      this.$router.push({ name: "home" });
    },
    dashboard(){
        this.$router.push({name: "dashboard"});
    },
    logout() {
      this.$store.dispatch("logout");
    },
    createAccount() {
      this.$store.dispatch("createAccount");
    }
  }
};
</script>

<style>
</style>