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
            <form className='form' method='post' action='/api' onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="id">Name</label>
                    <input type="text" name='name' id='name'/>
                </div>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input type="email" name='email' id='email'/>
                </div>
                <button type='submit'>Я ем спаржу!</button>
            </form>
        </div>
    );
};

export default MainForm;