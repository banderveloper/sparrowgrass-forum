import React, {useEffect, useState} from 'react';
import RecordItem from "./RecordItem";

const RecordList = () => {

    const [records, setRecords] = useState([]);

    useEffect(() => {

        fetch('/api').then(response => {
            return response.json();
        }).then(json => {
            setRecords(json);
        });

    }, []);

    return (
        <div>
            {
                records.map((item, index) =>{
                  return <RecordItem name={item.name} count={item.count} key={index} />
                })
            }
        </div>
    );
};

export default RecordList;