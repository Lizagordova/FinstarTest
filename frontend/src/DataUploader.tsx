import { useState} from "react";
import {Alert, Button, Container, Grid, TextField} from "@mui/material";

const defaultData = {
    1: "value1",
    5: "value2",
    15: "value2"
};

const DataUploader = () => {
    const [jsonData, setJsonData] = useState(JSON.stringify(defaultData));
    const [errorMessage, setErrorMessage] = useState<string | null>(null);
    const [message, setMessage] = useState<string | null>(null);
    const uploadData = () => {
        const data = JSON.parse(jsonData);
            //todo: вынести адрес куда-нибудь
        fetch('https://localhost:44302/api/v1/save', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({Data: data})
        }).then(() => {
            setMessage('Данные успешно загружены')
        }).catch(err => setErrorMessage('Ошибка'));
    };
    
    const handleChange = (value: string) => {
        setErrorMessage(null);
        setJsonData(value);
    };

    return (
        <Grid container spacing={2}>
            <Grid item xs={12}>
                <TextField
                    id="outlined-multiline-static"
                    label="Введите данные"
                    multiline
                    rows={4}
                    defaultValue={jsonData}
                    variant="filled"
                    sx={{ width: '100%' }}
                    onChange={(e) => handleChange(e.target.value)}
                />
            </Grid>
            <Grid item xs={12}>
                <Button
                    onClick={uploadData}
                    variant="contained">
                    Загрузить
                </Button>
            </Grid>
            <Grid item xs={12}>
                {errorMessage && <Alert severity="error">{errorMessage}</Alert>}
                {message && <Alert severity="success">{message}</Alert>}
            </Grid>
        </Grid>
    );
}

export default DataUploader;