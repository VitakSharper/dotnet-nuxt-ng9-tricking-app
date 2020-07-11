<template>
  <div>

    <v-file-input accept="video/*" @change="handleFile"></v-file-input>

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
  </div>
</template>

<script>
  import {mapState, mapActions, mapMutations} from 'vuex'
  import Axios from "axios";

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
      },
      handleFile: async (file) => {
        if (!file) return;

        const form = new FormData();
        form.append('video', file)

        const result = await Axios.post('http://localhost:5000/api/videos', form)

        console.log('Result: ', result)
      }
    }
  }
</script>
