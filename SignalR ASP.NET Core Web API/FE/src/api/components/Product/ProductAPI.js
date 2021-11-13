import BaseAPI from '@/api/base/BaseAPI.js';

class ProductAPI extends BaseAPI {
    constructor() {
        super();
        this.controller = 'Product';
    }
}

export default new ProductAPI();