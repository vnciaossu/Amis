import moment from "moment";

export const func = {
  functionName: (data) => {
    console.log(data);
  },
  /**
   * TODO:Format tiền tệ
   * CreateBy:tmquy(17/05/2021)
   */
  fnFormatCurrency: function(num) {
    if (typeof num == "string") {
      while (num.indexOf(",") != -1) num = num.replace(",", "");
    }
    num = parseInt(num);
    num += "";

    var p = num.split(".");
    // acc: tích luỹ cộng dồn
    return p[0]
      .split("")
      .reverse()
      .reduce(function(acc, num, i) {
        return num == "-" ? acc : num + (i && !(i % 3) ? "," : "") + acc;
      }, "");
  },

  /**
   * TODO:Format DateTime
   * CreateBy:tmquy(17/05/2021)
   */
  fnFormatDate: function(dateInput) {
    if (dateInput == null) {
      return null;
    } else {
      return moment(String(dateInput)).format("DD/MM/YYYY");
    }
  },

  /**
   * TODO:Format date bind vào input
   * CreateBy:tmquy(17/05/2021)
   */
  fnFormatDateInput: function(dateInput) {
    return moment(dateInput).format("YYYY-MM-DD");
  },

  /**
   * TODO:Validate email
   * CreateBy:tmquy(17/05/2021)
   */
  validateEmail: function(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
  },

  /**
   *Di chuyển dialog
   *CreateBy:tmquy(19/05/2021)
   */
  move: function(divid, xpos, ypos) {
    divid.style.left = xpos + "px";
    divid.style.top = ypos + "px";
  },
  startMoving: function(divid, wrapper, evt) {
    evt = evt || window.event;
    var rect = divid.getBoundingClientRect();
    var posX = evt.clientX,
      posY = evt.clientY,
      divTop = rect.top,
      divLeft = rect.left,
      //width height div
      eWi = parseInt(divid.style.width),
      eHe = parseInt(divid.style.height),
      //width height wrapper
      cWi = parseInt(document.getElementById(wrapper).style.width),
      cHe = parseInt(document.getElementById(wrapper).style.height);
    //width cursor to modal
    var diffX = posX - divLeft,
      diffY = posY - divTop;
    //chỉ cho phép drag ở cùng chỉ định
    if (diffY > 50) {
      return;
    }
    divid.onmousemove = function(evt) {
      evt = evt || window.event;
      var posX = evt.clientX,
        posY = evt.clientY,
        aX = posX - diffX,
        aY = posY - diffY;
      if (aY < -50) this.stopMoving(divid);
      if (aX < 0) aX = 0;
      if (aY < 0) aY = 0;
      if (aX + eWi > cWi) aX = cWi - eWi;
      if (aY + eHe > cHe) aY = cHe - eHe;
      func.move(divid, aX, aY);
    };
  },
  stopMoving: function(divid) {
    divid.onmousemove = function() {};
  },
};
