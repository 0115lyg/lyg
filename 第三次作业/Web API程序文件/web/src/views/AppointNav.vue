<template>
  <div>
    <el-input type="text" v-model="library">{{library}}</el-input>
    <el-button @click="findZone">查找区域</el-button>
    <el-input type="text" v-model="zone">{{zone}}</el-input>
    <el-button @click="findSeat">查找座位</el-button>
    <el-input type="text" v-model="seat">{{seat}}</el-input>

    <el-table :data="tableData" style="width: 100%" v-if="isShow">
      <el-table-column prop="library" label="图书馆" width="180"></el-table-column>
      <el-table-column prop="zone" label="区域" width="180"></el-table-column>
      <el-table-column prop="seat" label="座位"></el-table-column>
    </el-table>
  </div>
</template>

<script>
import {request} from "../network/request";

export default {
  name: "AppointNav",
  data() {
    return {
      library: "信息馆",
      zone: "",
      seat: [],
      isShow: false,
      tableData: []
    }
  },
  methods: {
    findZone() {
      let that = this
      request({
        url: '/zone',
        method: 'post',
        params: {"library": that.library}
      }).then(
          res => that.zone = res
      ).catch(
          err => console.log(err)
      )
    },
    findSeat() {
      let that = this
      request({
        url: '/seat',
        method: 'post',
        params: {"library": that.library, "zone": that.zone[0]}
      }).then(
          res => {
            that.tableData = []
            that.seat = res
            for (let x of that.seat){
              that.tableData.push({
                library: that.library,
                zone: that.zone,
                seat: x
              })
            }
            that.isShow = true}

      ).catch(
          err => console.log(err)
      )
    }
  },
  mounted() {

  }
}
</script>

<style scoped>

</style>