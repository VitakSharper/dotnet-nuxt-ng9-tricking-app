<template>
  <v-dialog :value="active" persistent :width="type===uploadType.TRICK?'930':'750'">
    <trick-steps/>
  </v-dialog>
</template>

<script>
  import {mapState, mapActions, mapMutations} from 'vuex'
  import {UPLOAD_TYPE} from "../../data/enum"
  import TrickSteps from "./trick-steps";

  export default {
    components: {TrickSteps},
    computed: {
      ...mapState('video-upload', ['uploadPromise', 'active', 'step', 'type']),
      uploadType() {
        return UPLOAD_TYPE
      }
    },
    methods: {
      ...mapMutations('video-upload', ['reset', 'toggleActivity', 'setType', 'incStep']),
      ...mapActions('video-upload', ['startVideoUpload', 'createTrick']),
    }
  }
</script>

<style scoped>

</style>
