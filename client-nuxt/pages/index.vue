<template>
  <div>
    <div v-if="tricks">
      <div v-for="(trick,index) in tricks" :key="trick.id">
        {{index+1}} - {{trick.name}}
        <div>
          <video width="400" controls :src="`http://localhost:5000/api/videos/${trick.video}`"></video>
        </div>
      </div>
    </div>

    <div v-if="submissions">
      <div v-for="(sub,index) in submissions" :key="sub.id">
        {{index+1}} - {{sub.description}} - {{sub.id}}
        <div>
          <video width="400" controls :src="`http://localhost:5000/api/videos/${sub.video}`"></video>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import {mapState} from 'vuex'

  export default {

    computed: {
      ...mapState('tricks', ['tricks']),
      ...mapState('submissions', ['submissions'])
    },
  }
</script>
