import React from 'react';

const RecordItem = ({name, count}) => {
    return (
        <div>
            <p>{name} уже ел спаржу {count} раз!</p>
        </div>
    );
};

export default RecordItem;