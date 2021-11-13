class Tooltip {
  /**
   * Lắng nghe sự kiện hiển thị và ẩn input (hover event)
   * @param {string} message
   * CreatedBy: NTDUNG (28/08/2021)
   */
  tooltipListeners(message) {
    return Object.assign({}, this.$listener, {
      mouseenter: event => {
        // Truyền nội dung và vị trí cho tooltip
        var tooltipStyle = {
          message: message,
          top: event.clientY,
          left: event.clientX
        };
        // Hiện tooltip
        this.$bus.$emit("showTooltip", tooltipStyle);
      },
      mouseleave: () => {
        // Ẩn tooltip
        this.$bus.$emit("hideTooltip");
      },
      mouseup: event => {
        setTimeout(() => {
          if (!this.isVisible(event.target)) {
            this.$bus.$emit("hideTooltip");
          }
        }, 100);
      }
    });
  }
}
export default new Tooltip();
