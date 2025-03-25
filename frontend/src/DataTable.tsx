import {ChangeEvent, useEffect, useState} from "react";
import {
    Paper,
    Box,
    TextField,
    Button, TablePagination, TableContainer, TableHead, Table, TableRow, TableCell, TableBody
} from "@mui/material";
import {BackendUrl} from "./constants";

type Item = {
    id: number;
    code: number;
    value: string;
}

const DataTable = () => {
    const [items, setItems] = useState<Item[]>([]);
    const [totalCount, setTotalCount] = useState<number>(0);
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
        fetch(`${BackendUrl}/api/v1/get?${params.toString()}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Ошибка запроса');
                }
                return response.json();
            })
            .then(data => {
                setItems(data.items);
                setTotalCount(data.totalCount);
            })
            .catch(error => console.error('Ошибка:', error));
    }
    
    const handleChangePageSize = (event: ChangeEvent<HTMLInputElement>) => {
        setPageSize(parseInt(event.target.value, 10));
        getItems();
    }

    const handleChangePage =  (event: unknown, newPage: number)  => {
        setPage(newPage);
        getItems();
    }
    
    useEffect(() => {
        getItems();
    }, [page, pageSize]);

    return (
        <Paper sx={{ p: 2 }}>
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
            <TableContainer sx={{ maxHeight: '400px', overflow: 'auto' }}>
                <Table stickyHeader >
                    <TableHead>
                        <TableRow>
                            <TableCell>id</TableCell>
                            <TableCell>code</TableCell>
                            <TableCell>value</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {items.map(item => (
                            <TableRow key={item.id}>
                                <TableCell>{item.id}</TableCell>
                                <TableCell>{item.code}</TableCell>
                                <TableCell>{item.value}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <TablePagination
                rowsPerPageOptions={[5, 10, 25]}
                component="div"
                count={totalCount}
                rowsPerPage={pageSize}
                page={page}
                onPageChange={handleChangePage}
                onRowsPerPageChange={handleChangePageSize}
            />

            {error && (
                <Box sx={{ color: 'error.main', p: 2 }}>
                    Ошибка: {error}
                </Box>
            )}
        </Paper>
    )
}

export default DataTable;