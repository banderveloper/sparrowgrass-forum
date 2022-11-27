import axios from "axios";

export default class RecordsService {

    static async getAll() {
        return await axios.get('/api');
    }
    static async post(name, email){
        return await axios.post('/api', {
           name: name,
           email: email
        });
    }
};
