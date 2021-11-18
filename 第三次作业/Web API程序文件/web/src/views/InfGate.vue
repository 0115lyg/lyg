<template>
  <el-row>
    <el-col :offset=2>
      <div id="drawPie" style="width: 700px; height: 350px; margin-top: 10px"></div>
    </el-col>
  </el-row>
</template>

<script>
import * as echarts from "echarts";
export default {
  name: "InfGate",
  mounted() {
    this.draw()
  },
  methods: {
    draw() {
      let firstChart = echarts.init(document.getElementById("drawPie"), null, {})
      let option = {
        title: [{text: "预约图书馆统计", left: '16%'}, {text: "预约区域统计", left: '53%'}],
        legend: {x: '27%', bottom: 0, data: ['A', 'B', 'C', 'D', 'E']},
        series: [
          {
            name: 'firstChart',
            type: 'pie',
            left: '0',
            radius: ['40%', '60%'],
            center: ['25%', '50%'],
            label: {show: false, emphasis: {show: true}},
            // labelLine: { show: false },
            emphasis: {
              label: {show: true, fontSize: '30', fontWeight: 'bold'}
            },
            data: [
              {value: 335, name: 'A'},
              {value: 310, name: 'B'},
              {value: 234, name: 'C'},
              {value: 135, name: 'D'},
              {value: 1548, name: 'E'}
            ]
          },
          {
            name: 'secondChart',
            type: 'pie',
            right: '15%',
            radius: ['40%', '60%'],
            center: ['75%', '50%'],
            label: {show: false, emphasis: {show: true}},
            // labelLine: { show: false },
            emphasis: {
              label: {show: true, fontSize: '30', fontWeight: 'bold'}
            },
            data: [
              {value: 335, name: 'A'},
              {value: 530, name: 'B'},
              {value: 780, name: 'C'},
              {value: 185, name: 'D'},
              {value: 255, name: 'E'}
            ]
          }
        ]
      }
      firstChart.setOption(option)
    }
  }
}
</script>

<style scoped>

</style>