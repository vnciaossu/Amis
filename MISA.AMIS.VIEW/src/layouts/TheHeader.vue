<template>
  <div class="header">
    <div class="header__select flex items-center">
      <div class="three-stripes"></div>
      <div class="branch-name">CÔNG TY CỔ PHẦN MISA</div>
      <div class="flex items-center">
        <a href="" class="icon-chevron"></a>
      </div>
    </div>

    <div class="header__user flex items-center">
      <div class="header__user--noti cursor"></div>
      <div class="header__user--avt cursor"></div>
      <div class="header__user--name cursor">Từ Minh Quý</div>
      <div class="header__user--action cursor"></div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.body-right .header {
  background-color: rgb(255, 255, 255);
  display: flex;
  width: 100%;
  height: 50px;
  justify-content: space-between;
  align-items: center;
  padding-right: 20px;
}

.body-right .header .header__user {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.body-right .header .header__select select {
  padding: 5px;
  border: none;
}

.body-right .header .header__select .three-stripes {
  width: 24px;
  height: 24px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -843px -30px;
  margin: 0px 10px;
  cursor: pointer;
}

.body-right .header .header__select .branch-name {
  width: 180px;
  height: 20px;
  font-size: 14px;
  padding-left: 10px;
  font-weight: 600;
}

.body-right .header .header__select .icon-chevron {
  width: 14px;
  height: 14px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -80px -360px;
  transform: rotate(90deg);
  margin-left: 5px;
}

.body-right .header .header__select select:focus {
  outline: none;
  box-shadow: none !important;
}

.body-right .header .header__user {
  padding: 0px 16px 0px 0px;
}

.body-right .header .header__user .header__user--noti {
  width: 24px;
  height: 24px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -788px -30px;
  margin-right: 20px;
}

.body-right .header .header__user .header__user--avt {
  width: 32px;
  height: 32px;
  background-repeat: no-repeat;
  background-size: 30px;
  background-position: center;
  border-radius: 50%;
  background-image: url("../assets/img/default-avatar.jpg");
  margin-bottom: 5px;
}

.body-right .header .header__user .header__user--name {
  font-weight: 600;
}

.body-right .header .header__user .header__user--action {
  width: 14px;
  height: 14px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -1076px -32px;
  margin-left: 5px;
}

.cursor {
  cursor: pointer;
}
</style>
