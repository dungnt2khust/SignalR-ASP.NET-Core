import BaseAPIConfig from './BaseAPIConfig.js'

export default class BaseAPI {
	constructor() {
	}

	controller = "";

	/**
	 * Lấy tất cả thông tin
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	getAll(route) {
		route = route ? route : '';
		return BaseAPIConfig.get(this.controller + route);
	}

	/**
	 * Lấy theo id
	 * @param {string} id
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	getById(id) {
		return BaseAPIConfig.get(this.controller + "/" + id);
	}

	/**
	 * thêm mới
	 * @param {object} body thông tin cần thêm
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	async post(body) {
		return await BaseAPIConfig.post(this.controller, body);
	}

	/**
	 * Chỉnh sửa theo Id
	 * @param {string} id
	 * @param {object} body thông tin chỉnh sửa
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	async put(id, body) {
		return await BaseAPIConfig.put(this.controller + "/" + id, body);
	}

	/**
	 * Xóa nhiều theo Id
	 * @param {Array} listData mảng chứa các id
	 * @returns promise get từ call axios api
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	async deleteMany(body) {
		return await BaseAPIConfig.delete(this.controller, { data: body });
	}
	/**
	 * Xóa theo id
	 * @param {string} id  id của đối tượng
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	delete(id) {
		return BaseAPIConfig.delete(this.controller + "/" + id);
	}

	/**
	 * Lấy mã mới
	 * @returns {Promise}
	 * CreatedBy: NTDUNG (07/10/2021)
	 */
	getNewCode() {
		return BaseAPIConfig.get(this.controller + "/NewCode");
	}

    /**
     * Lọc và phân trang
     * @param {String} filterString 
     * @param {Number} pageNumber 
     * @param {Number} pageSize 
     * @param {Array} totalFields 
     * @returns {Promise}
     * CreatedBy: NTDUNG(29/10/2021)
     */
    getFilterPaging(filterString, pageNumber, pageSize, totalFields = []) {
        let api = this.controller + `/Paging?filterString=${filterString}&pageNumber=${pageNumber}&pageSize=${pageSize}`;
        return BaseAPIConfig.post(api, totalFields);
    }
}
