<template>
  <div>
    <TheHeader
      @sidenavToggle="displaySidenav = !displaySidenav"
    />
    <TheSidenav
      :show="displaySidenav"
      @close="displaySidenav = false" />
    <nuxt/>
  </div>
</template>

<script>
  import TheHeader from "@/components/v1/Navigation/TheHeader";
  import TheSidenav from "@/components/v1/Navigation/TheSidenav";
  export default {
    components:{
      TheHeader,
      TheSidenav
    },
    data() {
      return {
        displaySidenav: false
      }
    }
  }
</script>

<style>
  html {
    font-family: 'Open Sans', sans-serif;
  }

  body {
    margin: 0;
  }
</style>
