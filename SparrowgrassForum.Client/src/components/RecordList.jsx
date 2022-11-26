import React, {useEffect, useState} from 'react';
import RecordItem from "./RecordItem";
import useFetching from "../hooks/useFetching";
import RecordsService from "../API/RecordsService";

const RecordList = () => {

    const [records, setRecords] = useState([]);
    const [fetchRecords, isLoading, errors] = useFetching(async () => {

        const response = await RecordsService.getAll();
        setRecords(response.data);
    });

    useEffect(() => {
        fetchRecords();
    }, []);

    return (
        <div>
            {
                !isLoading ?
                    records.map((item, index) => {
                        return <RecordItem name={item.name} count={item.count} key={index}/>
                    })
                    :
                    <h1>Loading...</h1>
            }
        </div>
    );
};

export default RecordList;