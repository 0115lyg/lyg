<template>
  <div>
    <el-container class="background">
      <!--标题栏-->
      <el-header>
        <el-col :span=10 :offset=1><span style="color: white; font-size: large">自习预约系统</span></el-col>
        <el-col :span=2 :offset=10>
          <el-button
              type="primary"
              icon="el-icon-user-solid"
              circle
          ></el-button>
          <el-button
              type="primary"
              icon="el-icon-message"
              circle
          ></el-button>
        </el-col>
        <el-col :span=1>
          <el-button>登出</el-button>
        </el-col>
      </el-header>
      <!--侧栏-->
      <el-container>
        <el-aside width="200px" id="Aside">
          <el-row>
            <el-menu default-active="1">

              <router-link tag="div" to="/InfGate">
                <el-menu-item index="1">
                  <i class="el-icon-star-on"></i>
                  <span slot="title">今日预约</span>
                </el-menu-item>
              </router-link>

              <router-link tag="div" to="/AppointNav">
                <el-menu-item index="2">
                  <i class="el-icon-search"></i>
                  <span slot="title">预约导航</span>
                </el-menu-item>
              </router-link>

              <router-link tag="div" to="/AppointDoc">
                <el-menu-item index="3">
                  <i class="el-icon-document"></i>
                  <span slot="title">预约记录</span>
                </el-menu-item>
              </router-link>

              <router-link tag="div" to="/Set">
                <el-menu-item index="4" v-if="">
                  <i class="el-icon-menu"></i>
                  <span slot="title">设置</span>
                </el-menu-item>
              </router-link>
            </el-menu>
          </el-row>
        </el-aside>
        <!--主界面-->
        <el-container>
          <router-view></router-view>
        </el-container>
      </el-container>
    </el-container>

  </div>
</template>

<script>
export default {
  name: "MainView",
  data() {
    return {

    }
  },
}
</script>

<style>
.background {
  padding: 0;
  margin: 0;
  height: 100%;
  position: absolute;
  left: 0;
  right: 0;
}
.el-header {
  background: linear-gradient(to top, #6495ED, #1E90FF);
  text-align: left;
  line-height: 55px;
}
</style>