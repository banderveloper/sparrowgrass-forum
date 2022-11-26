import axios from "axios";

export default class RecordsService {

    static async getAll() {
        return await axios.get('/api');
    }
};
