import {useEffect, useState} from "react";
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import {
    Paper,
    Box,
    TextField,
    Button,
} from "@mui/material";

type Item = {
    id: number;
    code: number;
    value: string;
}
const columns: GridColDef[] = [
    { field: 'id', headerName: '№', width: 70 },
    { field: 'code', headerName: 'Код', width: 130 },
    { field: 'value', headerName: 'Значение', flex: 1 },
];
const DataTable = () => {
    const [items, setItems] = useState<Item[]>([]);
    const[codeFilter, setCodeFilter] = useState<string | null>('');
    const[valueFilter, setValueFilter] = useState<string | null >('');
    const [error, setError] = useState<string | null>(null);
    const [page, setPage] = useState<any>(1);
    const [pageSize, setPageSize] = useState<any>(5);
    
    const getItems = () => {
        const params = new URLSearchParams();
        if (codeFilter) params.append('codeFilter', codeFilter);
        if (valueFilter) params.append('valueFilter', valueFilter);
        params.append('page', page);
        params.append('pageSize', pageSize);
        fetch(`https://localhost:44302/api/v1/get?${params.toString()}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Ошибка запроса');
                }
                return response.json();
            })
            .then(data => {
                setItems(data.items);
            })
            .catch(error => console.error('Ошибка:', error));
    }
    useEffect(() => {
       // getItems();
    }, [items]);
    return (
        <Paper sx={{ p: 2, height: '100%' }}>
            <Box sx={{ mb: 2 }}>
                <Box display="flex" gap={2}>
                    <TextField
                        label="Фильтр по коду"
                        variant="outlined"
                        size="small"
                        value={codeFilter}
                        onChange={(e) => setCodeFilter(e.target.value)}
                    />
                    <TextField
                        label="Фильтр по значению"
                        variant="outlined"
                        size="small"
                        value={valueFilter}
                        onChange={(e) => setValueFilter(e.target.value)}
                    />
                    <Button
                        variant="contained"
                        onClick={getItems}
                    >
                        Получить данные
                    </Button>
                </Box>
            </Box>

            {error && (
                <Box sx={{ color: 'error.main', p: 2 }}>
                    Ошибка: {error}
                </Box>
            )}
            {!error && (
                <div style={{ height: 600, width: '100%' }}>
                    <DataGrid
                        rows={items}
                        columns={columns}
                        //@ts-ignore
                        page={page}
                        onPageChange={(newPage: any) => setPage(newPage)}
                        pageSize={pageSize}
                        onPageSizeChange={(newPageSize: any) => setPageSize(newPageSize)}
                        rowsPerPageOptions={[5, 10, 20]}
                        pagination
                    />
                </div>
            )}
        </Paper>
    )
}

export default DataTable;