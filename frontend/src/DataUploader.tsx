import {useEffect, useState} from "react";

const defaultData = {
    1: "value1",
    5: "value2",
    15: "value2"
};

const DataUploader = () => {
    const [jsonData, setJsonData] = useState(JSON.stringify(defaultData));

  //  const [message, setMessage] = useState("");
    const uploadData = () => {
        const data = JSON.parse(jsonData);
        console.log('data',data);
        fetch('https://localhost:44302/api/v1/save', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({Data: data})
        }).then(() => {
            //todo: добавить обработку ошибок что setMessage 
        });
    };

    return (
        <div>
            <h3>Загрузить данные</h3>
            <form onSubmit={uploadData}>
                <textarea
                    value={jsonData}
                    rows={5}
                    cols={50}
                    required
                    onChange={(e) => setJsonData(e.target.value)}
                />
                <button type="submit">Загрузить</button>
            </form>
            <input type="number" id="codeFilter" placeholder="Filter by Code"/>
        </div>
    )
}

export default DataUploader;