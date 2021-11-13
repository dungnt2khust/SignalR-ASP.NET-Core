class Popup {
    constructor(){};
    /**
     * Gọi đến dialog
     * @param {string} type kiểu của dialog (ERROR, WARN)
     * @param {string} message thông điệp muốn hiển thị
     * CreatedBy: NTDUNG (31/08/2021)
     */
    popup(type, message) {
        
    }
    confirmDelete(message) {
        var result = confirm(message);
        if (result) {
            console.log('yes');
        } else {
            console.log('no')
        }
    }
}
export default new Popup();