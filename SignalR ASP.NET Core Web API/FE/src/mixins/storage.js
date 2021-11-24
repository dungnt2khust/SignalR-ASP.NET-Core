export default {
    methods: {
        _getLocalStorage(key) {
            return localStorage.getItem(key);
        },
        _setLocalStorage(key, value) {
            return localStorage.setItem(key, value);
        },
        _removeLocalStorage(key) {
            return localStorage.removeItem(key);
        },
        _getSessionStorage(key) {
            return sessionStorage.getItem(key);
        },
        _setSessionStorage(key, value) {
            return sessionStorage.setItem(key, value);
        }
    } 
}
