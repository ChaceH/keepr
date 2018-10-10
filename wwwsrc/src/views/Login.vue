<template>
   <v-content id="login">
       <v-container fill-height>
           <v-layout justify-center align-center >
               <v-flex sm8 md4>
                   <div class="login">
                       <v-card v-if="loginForm" >
                           <v-toolbar card dark color="black">
                               <v-icon color="white" large>fas fa-skull</v-icon>
                               <v-toolbar-title>Login</v-toolbar-title>
                                <v-spacer></v-spacer>
                               <v-btn flat round @click="loginForm = !loginForm" class="white--text">
                                   sign up
                               </v-btn>
                           </v-toolbar>
                           <form @submit.prevent="loginUser">
                               <v-text-field class="field" prepend-icon="mail" color="black" single-line v-model="creds.email" placeholder="email"></v-text-field>
                               <v-text-field class="field" type="password" prepend-icon="lock" color="black" single-line v-model="creds.password" placeholder="password"></v-text-field>
                               <v-btn type="submit" color="grey">login</v-btn>
                           </form>
                       </v-card>
                       <v-card v-else>
                           <v-toolbar card color="black">
                               <v-icon color="white" large>fas fa-skull</v-icon>
                               <v-toolbar-title>Create Accout</v-toolbar-title>
                               <v-spacer></v-spacer>
                               <v-btn flat round @click="loginForm = !loginForm" class="white--text">
                                   login
                               </v-btn>
                           </v-toolbar>
                           <form @submit.prevent="register">
                               <v-text-field class="field" prepend-icon="person" color="black" single-line v-model="newUser.name" placeholder="username"></v-text-field>
                               <v-text-field class="field" prepend-icon="mail" color="black" single-line v-model="newUser.email" placeholder="email"></v-text-field>
                               <v-text-field class="field" type="password" prepend-icon="lock" color="black" single-line v-model="newUser.password" placeholder="password"></v-text-field>
                               <v-btn type="submit" color="grey">register</v-btn>
                           </form>
                       </v-card>
                   </div>
                   <v-layout>
                       <router-link :to="{name: 'home', params: {browsing: true}}" class="black--text">Continue as guest</router-link>
                   </v-layout>
               </v-flex>
           </v-layout>
       </v-container>
   </v-content>
</template>

<script>
export default {
  name: "login",
  mounted() {
    //checks for valid session
    this.$store.dispatch("authenticate");
  },
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
    }
  }
};
</script>