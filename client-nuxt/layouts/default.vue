<template>
  <v-app dark>
    <!--      APP-BAR-->
    <v-app-bar app dense>
      <v-toolbar-title>Tricking Library</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn depressed @click="toggleActivity">
        UPLOAD
      </v-btn>
    </v-app-bar>
    <!--      MAIN-->
    <video-upload/>
    <v-main>
      <nuxt/>
    </v-main>
  </v-app>
</template>

<script>
  import {mapMutations} from 'vuex'
  import VideoUpload from '../components/video-upload'

  export default {
    components: {
      VideoUpload
    },
    methods: mapMutations('video-upload', ['toggleActivity'])
  }
</script>
