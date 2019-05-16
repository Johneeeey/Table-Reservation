class TableList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Tables: [],
        };
        this.props = {
            requestAddress: '',
        };
    }
    loadData() {
        fetch(this.props.requestAddress).then(results => { return results.json() }).then(data => {
            this.setState({ Tables: data });
        }).catch(() => {
            alert('Error');
        });
    }
    componentWillMount() {
        this.loadData();
    }
    render() {
        return (
            <table className="table table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Номер столика</th>
                        <th>Количество мест</th>
                        <th>Цвет</th>
                        <th>Форма</th>
                        <th>Статус</th>
                        <th>Номер владельца</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.Tables.map(item => {
                        if (item.status == "Занят") {
                            var adres = "/Home/RemoveAReservation/?TableNumber=" + item.tableNumber;
                            return (
                                <tr key={item.tableNumber}>
                                    <td>{item.tableNumber}</td>
                                    <td>{item.seatsCount}</td>
                                    <td>{item.color}</td>
                                    <td>{item.formFactor}</td>
                                    <td>{item.status}</td>
                                    <td>{item.ownerId}</td>
                                    <td>
                                        <a href={adres}><input type="button" value="Отменить" id="TableListActionButton" /></a>
                                    </td>
                                </tr>
                            );
                        }
                        else {
                            var adres = "/Home/MakeAReservation/?TableNumber=" + item.tableNumber;
                            return (
                                <tr key={item.tableNumber}>
                                    <td>{item.tableNumber}</td>
                                    <td>{item.seatsCount}</td>
                                    <td>{item.color}</td>
                                    <td>{item.formFactor}</td>
                                    <td>{item.status}</td>
                                    <td>{item.ownerId}</td>
                                    <td>
                                        <a href={adres}><input type="button" value="Забронировать" id="TableListActionButton" /></a>
                                    </td>
                                </tr>
                            );
                        }
                    })
                    }
                </tbody>
            </table>
        );
    }
}

ReactDOM.render(<TableList requestAddress="/Home/GetTables" />, document.getElementById('idxRoot'))