import BaseAPIConfig from "@/api/base/BaseAPIConfig.js";
class Account {
  AccountData = {};
  constructor() {
    this.controller = "Account";
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
   * @param {Object} account
   * CreatedBy: NTDUNG (15/11/2021)
   * ModifiedBy: NTDUNG (22/11/2021)
   */
  checkValidAccount(account) {
    return BaseAPIConfig.post(
      `${this.controller}/check-valid-account`, account
    );
  } 
}

export default new Account();
