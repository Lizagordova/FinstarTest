import React, { useEffect, useState } from 'react';

import './App.css';
import DataUploader from './DataUploader';
import DataTable from "./DataTable";

function App() {
  return (
    <div className="App">
      <DataUploader />
      <DataTable />
    </div>
  );
}

export default App;
