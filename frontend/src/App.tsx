import React from 'react';

import './App.css';
import DataUploader from './DataUploader';
import DataTable from "./DataTable";
import {Container} from "@mui/material";

function App() {
  return (
    <Container maxWidth="md" sx={{ mt: 2, mb: 2 }}>
      <DataUploader />
      <DataTable />
    </Container>
  );
}

export default App;
