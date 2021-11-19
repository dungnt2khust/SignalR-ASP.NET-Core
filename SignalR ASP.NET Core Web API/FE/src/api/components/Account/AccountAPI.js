import BaseAPIConfig from "@/api/base/BaseAPIConfig.js";
class Account {
  constructor() {
    this.controller = "Account";
    this.AccountData = {};
  }
  /**
   * Kiểm tra session
   * CreatedBy: NTDUNG (15/11/2021)
   */
  checkSession() {
    return BaseAPIConfig.post(
      `${this.controller}/check-session?sessionID=${localStorage.getItem("Session")}`
    )
  }
  
  /**
   * Kiểm tra tài khoản
   * @param {String} type
   * @param {Object} account
   * CreatedBy: NTDUNG (15/11/2021)
   */
  checkValidAccount(type, account) {
    return BaseAPIConfig.post(
      `${this.controller}/${type}/check-valid-account`, account
    );
  }
}

export default new Account();
