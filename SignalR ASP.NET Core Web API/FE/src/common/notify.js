class Notify {
    constructor(){};
    /**
     * Gọi đến dialog
     * @param {string} type kiểu của dialog (ERROR, WARN)
     * @param {string} message thông điệp muốn hiển thị
     * CreatedBy: NTDUNG (31/08/2021)
     */
    popup(type, message) {
        return new Promise((resolve, reject) => {
            // Set lại giá trị ban đầu cho dialog answer
            this.dialogAnswer = "";

            // Gọi đến sự kiện show dialog
            this.$bus.$emit("showDialog", { type: type, message: message });

            // Tạo sự kiện lắng nghe kết quả trả về của dialog
            this.$bus.$on("dialogConfirm", (data) => {
                // Huỷ sự kiện lắng nghe
                this.$bus.$off("dialogConfirm");

                // Gán kết quả
                this.dialogAnswer = data;
            });

            // Đợi trả về giá trị khi có câu trả lời
            let count = 0;
            let wait = setInterval(() => {
                count++;
                if (this.dialogAnswer !== "") {
                    clearInterval(wait);
                    resolve(this.dialogAnswer);
                }
                if (count >= 10000) {
                    reject();
                }
            }, 20);
        });
    }
}
export default new Notify();