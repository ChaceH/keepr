<template>
<div class="keep card " style="box-shadow: 3px 3px 3px black; margin-bottom: 2rem;">
  <div class="top-buttons">
    <button class="btn button"><i class="far fa-edit"></i></button>
    <button class="btn button" @click="deleteKeep()"><i class="fa fa-trash"></i></button>
  </div>
    <div class="container">
      <img :src="keepData.img" alt="" class="image">
      <div class="overlay">
        <div class="icon">
          <button class="btn button" @click="view()"><i class="icon-color far fa-eye">:{{keepData.views}}</i></button>
          <button class="btn button" @click="share()"><i class="icon-color fas fa-share-square">:{{keepData.shares}}</i></button>
          <button class="btn button" @click="showModal()"><i class="icon-color far fa-save">:{{keepData.keeps}}</i></button>
        </div>
      </div>
    </div>


<!-- The Modal -->
<div :id="'myModal'+ keepData.id" class="modal">

  <!-- Modal content -->
  <div class="modal-content container-fluid">
    <span style="color: white;" class="close">&times;</span>
  <div class="modal-header row">
    <div class="col">
    <h4>SAVE KEEP TO VAULT</h4>
    </div>
  </div>
  <div class="modal-body row">
    <div class="col">
      <select v-model="selectedVaultId" style="background-color: white; height: 30px; color: black;">
        <option disabled value="" style="color: black;">Select Vault</option>
        <option style="color: black;" v-for="vault in vaults" :value="vault.id" :key="vault.id">
          {{vault.name}}
        </option>
      </select>
      <button class="btn btn-success btn-sm" @click="save()" style="height: 30px">Save</button>
      </div>
  </div>
</div>

</div>
<!-- The Modal -->


  <h3 style="">{{keepData.name}}</h3>
  <p style="">{{keepData.description}}</p>
</div>
</template>


<script>
import vault from "@/components/Vault.vue";

export default {
  name: "keep",
  props: ["keepData"],
  mounted() {
    if (this.$store.state.user.id) {
    this.$store.dispatch("getVaultsByUserId", this.$store.state.user.id);
    }
    console.log(this.keepData.id)
  },
  data() {
      return {
        selectedVaultId: ""
      };
    },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
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
    save() {
      console.log(this.keepData.id)
      if(this.selectedVaultId){
        this.$store.dispatch("addKeepToVault", {
          keepId: this.keepData.id,
          vaultId: this.selectedVaultId
        });
      }
    },
    showModal() {
      console.log(this.keepData.id)
      var modal = document.getElementById("myModal"+this.keepData.id);
      var span = document.getElementsByClassName("close")[this.$store.state.keeps.findIndex(keep => keep.id === this.keepData.id)];
      modal.style.display = "block";
      span.onclick = function() {
        modal.style.display = "none";
      };
      window.onclick = function(event) {
        if (event.target == modal) {
          modal.style.display = "none";
        }
      };
    },
    showAvailableVaults() {}
  }
};
</script>


<style scoped>
.button {
  background-color: transparent;
}
.top-buttons {
  display: flex;
  justify-content: space-between;
}
.container {
  position: relative;
  width: 100%;
  max-width: 400px;
}
.image {
  display: block;
  width: 100%;
  height: 100%;
}
.overlay {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  height: 100%;
  width: 100%;
  opacity: 0;
  transition: 0.3s ease;
  background-color: black;
}
.container:hover .overlay {
  opacity: 0.7;
}
.icon {
  font-size: 100px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  text-align: center;
}
.icon-color {
  color: white;
  opacity: 1;
}

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0, 0, 0); /* Fallback color */
  background-color: rgba(0, 0, 0, 0.4); /* Black w/ opacity */
}

.modal-header {
  background-color: black;
  color: white;
}

/* Modal Content/Box */
.modal-content {
  background-color: black;
  margin: 15% auto; /* 15% from the top and centered */
  padding: 20px;
  border: 1px solid #888;
  height: 15%;
  width: 30%; /* Could be more or less, depending on screen size */
}

/* The Close Button */
.close {
  color: #aaa;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: black;
  text-decoration: none;
  cursor: pointer;
}
</style>
