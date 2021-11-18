<template>
  <el-table :data="tableData" style="width: 100%">
    <el-table-column prop="site" label="位置" width="300"></el-table-column>
    <el-table-column prop="time" label="时间" width="200"></el-table-column>
    <el-table-column prop="condition" label="状态"></el-table-column>
  </el-table>
</template>

<script>
import {request} from "../network/request";

export default {
  name: "AppointDoc",
  data() {
    return {
      tableData: []
    }
  },
  methods: {
    findAllReservation() {
      let that = this
      request({
        url: '/reservation',
        method: 'get'
      }).then(
          res => that.tableData = res
      ).catch(
          err => console.log(err)
      )
    },
  },
  mounted() {
    this.findAllReservation()
  }
}
</script>

<style scoped>

</style>