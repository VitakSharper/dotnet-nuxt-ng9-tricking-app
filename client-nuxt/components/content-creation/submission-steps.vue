<template>
  <!--        STEPPER-->
  <v-stepper v-model="step">
    <v-stepper-header>
      <v-stepper-step :complete="step > 3" step="3">Upload Video</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step :complete="step > 1" step="1">Select Trick</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step :complete="step > " step="4">Submission</v-stepper-step>
      <v-divider></v-divider>
      <v-stepper-step step="4">Review</v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>

      <v-stepper-content step="1">
        <div class="d-flex flex-column align-center">
          <v-btn class="my-2" @click="setType({type:uploadType.TRICK})">Trick</v-btn>
          <v-btn @click="setType({type:uploadType.SUBMISSION})">Submission</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="2">
        <div>
          <v-text-field label="Tricking Name" v-model="trickName"></v-text-field>
          <v-btn @click="incStep">Save Trick</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="3">
        <div>
          <v-file-input accept="video/*" @change="handleFile"></v-file-input>
        </div>
      </v-stepper-content>

      <v-stepper-content step="4">
        <div>
          <v-text-field label="Description" v-model="submission"></v-text-field>
          <v-btn @click="incStep">Save Submission</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="5">
        <div>
          <v-btn @click="save">Save</v-btn>
        </div>
      </v-stepper-content>
    </v-stepper-items>

  </v-stepper>
</template>

<script>
  import {mapState, mapActions, mapMutations} from 'vuex'

  const initState = () => ({
    step: 1,
    form: {
      trickId: '',
      video: '',
      submission: ''
    }
  })

  export default {
    data: initState,
    computed: mapState('video-upload', ['uploadPromise'])
    ,
    methods: {
      ...mapMutations('video-upload', ['reset', 'toggleActivity', 'setType', 'incStep']),
      ...mapActions('video-upload', ['startVideoUpload', 'createTrick']),

      async handleFile(file) {
        if (!file) return;
        const form = new FormData();
        form.append('video', file)
        this.startVideoUpload({form});
      }
      ,

      async save() {
        if (!this.uploadPromise) {
          console.log('Upload Task is null')
          return
        }
        const video = this.uploadPromise;
        await this.createTrick({
          trick: {
            name: this.trickName,
            submission: {description: this.submission, video, trickId: uuid.v4()}
          }
        });

        this.fetchTricks();
        this.fetchSubmissions();

        this.trickName = '';
        this.submission = '';
        this.reset();
      }
    }
  }
</script>

<style scoped>

</style>
