import BaseAPIConfig from "@/api/base/BaseAPIConfig.js";

class Account {
  constructor() {
    this.controller = "Account";
  }
  /**
   * Kiểm tra session
   * CreatedBy: NTDUNG (15/11/2021)
   */
  checkSession() {
    if (localStorage.getItem("Session"))
      BaseAPIConfig.post(
        `${this.controller}
        /check-session?sessionID=${localStorage.getItem("Session")}`
      )
        .then(res => {
          if (res.data.Data) {
            this.accountData = res.data.Data;
            return true;
          } else {
            return false;
          }
        })
        .catch(res => {
          alert(res);
        });
    else return false;
  }

  /**
   * Kiểm tra tài khoản
   * @param {String} type
   * @param {Object} account
   * CreatedBy: NTDUNG (15/11/2021)
   */
  checkValidAccount(type, account) {
    return BaseAPIConfig.post(
      `${this.controller}/${type}/check-valid-account`,
      account
    );
  }
}

export default new Account();
