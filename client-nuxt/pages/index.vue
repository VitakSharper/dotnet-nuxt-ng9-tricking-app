<template>
  <v-layout
    column
    justify-center
    align-center
  >
    <v-flex
      xs12
      sm8
      md6
    >
      <div class="text-center">
      </div>

      <div v-if="tricks">
        <p v-for="trick in tricks">
          {{trick.name}}
        </p>
      </div>

      <div>
        <v-text-field label="Tricking Name" v-model="trickName"></v-text-field>
        <v-btn @click="saveTrick">Save Tricks</v-btn>
      </div>
      <v-btn @click="resetTricks">Reset Tricks</v-btn>
    </v-flex>
  </v-layout>
</template>

<script>
  import {mapState, mapActions, mapMutations} from 'vuex'

  export default {
    data: () => ({
      trickName: '',
      step: 1
    }),
    computed:
      {
        ...mapState({
          message: state => state.message
        }),
        ...mapState('tricks', ['tricks'])
      },
    methods: {
      ...mapMutations(['reset']),
      ...mapMutations('tricks', {resetTricks: 'reset'}),
      ...mapActions('tricks', ['createTricks']),
      async saveTrick() {
        await this.createTricks({trick: {name: this.trickName}});
        this.trickName = '';
      }
    }
  }
</script>
