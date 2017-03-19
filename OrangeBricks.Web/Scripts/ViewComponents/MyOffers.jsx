var MyOffers = React.createClass({
    getInitialState: function () {
        return { data: this.props.intialData }
    },
    getBadge: function() {
    },
    render: function () {
        return (
            <a href={this.props.Url}>{this.props.Text}</a>
        );
    }
});