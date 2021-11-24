import BaseAPI from '@/api/base/BaseAPI.js';

class UserAPI extends BaseAPI {
    constructor() {
        super();
        this.controller = 'User';
    }
}

export default new UserAPI();