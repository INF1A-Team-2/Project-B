import os
import sys
import json
from flask import Flask, request, jsonify
from sql_database_zoutigewolf.database import Database


def load_data(file_name: str) -> dict[str]:
    with open(os.path.join(sys.path[0], file_name), "r") as f:
        return json.load(f)


config = load_data("Config.json")

app = Flask(__name__)
database = Database(**config["DatabaseCredentials"])


@app.post("/")
def execute():
    token = request.headers.get("Token", None)

    if not token or token != config["Token"]:
        return "Invalid token", 401

    query = request.json.get("Query", None)

    if not query:
        return "No query specified", 400

    values = request.json.get("Values", [])

    try:
        res = database.execute("project-b", query, values)

        return jsonify(res)

    except Exception as e:
        return str(e), 500


if __name__ == "__main__":
    app.run("0.0.0.0", 22222)
