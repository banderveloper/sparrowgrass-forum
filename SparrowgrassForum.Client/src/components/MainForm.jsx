import React from 'react';
import RecordsService from "../API/RecordsService";

const MainForm = () => {

    const handleSubmit = async event => {
        event.preventDefault();
        const form = event.target;

        const response = await RecordsService.post(form.name.value, form.email.value);

        if (response.status === 200) {
            document.location.href = '/records';
        }
    }

    return (
        <div className='form-block'>
            <form method='post' action='/api' onSubmit={handleSubmit}>
                <input type="text" name='name'/>
                <input type="email" name='email'/>
                <input type="submit"/>
            </form>
        </div>
    );
};

export default MainForm;