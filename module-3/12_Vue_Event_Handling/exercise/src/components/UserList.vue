<template>
  <div class="container">
    <table id="tblUsers">
      <thead>
        <tr>
          <th>&nbsp;</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
          <th>Email Address</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <input
              type="checkbox"
              id="selectAll"
              v-on:change="selectAll($event)"
              v-bind:checked="selectedUserIDs.length === users.length"
            />
          </td>
          <td>
            <input
              type="text"
              id="firstNameFilter"
              v-model="filter.firstName"
            />
          </td>
          <td>
            <input type="text" id="lastNameFilter" v-model="filter.lastName" />
          </td>
          <td>
            <input type="text" id="usernameFilter" v-model="filter.username" />
          </td>
          <td>
            <input type="text" id="emailFilter" v-model="filter.emailAddress" />
          </td>
          <td>
            <select id="statusFilter" v-model="filter.status">
              <option value>Show All</option>
              <option value="Active">Active</option>
              <option value="Disabled">Disabled</option>
            </select>
          </td>
          <td>&nbsp;</td>
        </tr>
        <tr
          v-for="user in filteredList"
          v-bind:key="user.id"
          v-bind:class="{ disabled: user.status === 'Disabled' }"
        >
          <td>
            <input
              type="checkbox"
              v-bind:id="user.id"
              v-bind:value="user.id"
              v-model="selectedUserIDs"
            />
          </td>
          <td>{{ user.firstName }}</td>
          <td>{{ user.lastName }}</td>
          <td>{{ user.username }}</td>
          <td>{{ user.emailAddress }}</td>
          <td>{{ user.status }}</td>
          <td>
            <button
              v-if="user.status === 'Disabled'"
              v-on:click="flipStatus(user.id)"
              class="btnEnableDisable"
            >
              Enable
            </button>
            <button
              v-if="user.status === 'Active'"
              v-on:click="flipStatus(user.id)"
              class="btnEnableDisable"
            >
              Disable
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="all-actions">
      <button v-on:click="enableSelectedUsers">Enable Users</button>
      <button v-on:click="disableSelectedUsers">Disable Users</button>
      <button v-on:click="deleteSelectedUsers">Delete Users</button>
    </div>

    <button v-show="!showForm" v-on:click.prevent="showForm = true">Add New User</button>

    <form
      v-on:submit.prevent="saveUser"
      v-show="showForm"
      id="frmAddNewUser"
    >
      <div class="field">
        <label for="firstName">First Name:</label>
        <input type="text" name="firstName" v-model="newUser.firstName" />
      </div>
      <div class="field">
        <label for="lastName">Last Name:</label>
        <input type="text" name="lastName" v-model="newUser.lastName" />
      </div>
      <div class="field">
        <label for="username">Username:</label>
        <input type="text" name="username" v-model="newUser.username" />
      </div>
      <div class="field">
        <label for="emailAddress">Email Address:</label>
        <input type="text" name="emailAddress" v-model="newUser.emailAddress" />
      </div>
      <button type="submit" class="btn save">Save User</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "user-list",
  data() {
    return {
      filter: {
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "",
      },
      showForm: false,
      selectedUserIDs: [],
      counter: 7,
      newUser: {
        id: null,
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "Active",
      },
      users: [
        {
          id: 1,
          firstName: "John",
          lastName: "Smith",
          username: "jsmith",
          emailAddress: "jsmith@gmail.com",
          status: "Active",
        },
        {
          id: 2,
          firstName: "Anna",
          lastName: "Bell",
          username: "abell",
          emailAddress: "abell@yahoo.com",
          status: "Active",
        },
        {
          id: 3,
          firstName: "George",
          lastName: "Best",
          username: "gbest",
          emailAddress: "gbest@gmail.com",
          status: "Disabled",
        },
        {
          id: 4,
          firstName: "Ben",
          lastName: "Carter",
          username: "bcarter",
          emailAddress: "bcarter@gmail.com",
          status: "Active",
        },
        {
          id: 5,
          firstName: "Katie",
          lastName: "Jackson",
          username: "kjackson",
          emailAddress: "kjackson@yahoo.com",
          status: "Active",
        },
        {
          id: 6,
          firstName: "Mark",
          lastName: "Smith",
          username: "msmith",
          emailAddress: "msmith@foo.com",
          status: "Disabled",
        },
      ],
    };
  },
  methods: {
    saveUser() {
      this.newUser.id = this.counter,
      this.users.unshift(this.newUser);
      this.resetForm();
      this.counter += 1;
    },
    resetForm(){
      this.showForm = false;
      this.newUser = {id: null,
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "Active",};
    },
    flipStatus(id) {
      this.user = this.users.find((item) => {
        return item.id === id;
      });
      if (this.user.status == "Active") {
        return (this.user.status = "Disabled");
      }
      if (this.user.status == "Disabled") {
        return (this.user.status = "Active");
      }
    },
    enableSelectedUsers() {
      this.selectedUserIDs.forEach((id) => {
        this.user = this.users.find((item) => {
          return item.id === id;
        });

        this.selectedUserIDs = [];
        return (this.user.status = "Active");
      });
    },
    disableSelectedUsers() {
      this.selectedUserIDs.forEach((id) => {
        this.user = this.users.find((item) => {
          return item.id === id;
        });

        this.selectedUserIDs = [];
        return (this.user.status = "Disabled");
      });
    },
    deleteSelectedUsers() {
      let newUsers = this.users.filter((user) => {
        return !this.selectedUserIDs.includes(user.id);
      });
      this.users = newUsers;
      this.selectedUserIDs = [];
    },
    selectAll(event) {
      if (event.target.checked) {
        this.selectedUserIDs = [];
        this.users.forEach((user) => this.selectedUserIDs.push(user.id));
      } else {
        this.selectedUserIDs = [];
      }
    },
  },
  computed: {
    filteredList() {
      let filteredUsers = this.users;
      if (this.filter.firstName != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.firstName
            .toLowerCase()
            .includes(this.filter.firstName.toLowerCase())
        );
      }
      if (this.filter.lastName != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.lastName
            .toLowerCase()
            .includes(this.filter.lastName.toLowerCase())
        );
      }
      if (this.filter.username != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.username
            .toLowerCase()
            .includes(this.filter.username.toLowerCase())
        );
      }
      if (this.filter.emailAddress != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.emailAddress
            .toLowerCase()
            .includes(this.filter.emailAddress.toLowerCase())
        );
      }
      if (this.filter.status != "") {
        filteredUsers = filteredUsers.filter(
          (user) => user.status === this.filter.status
        );
      }
      return filteredUsers;
    },
    actionButtonDisabled() {
      if (!this.selectedUserIDs.length == 0) {
        return false;
      } else {
        return true;
      }
    },
  },
};
</script>

<style scoped>
table {
  margin-top: 20px;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  margin-bottom: 20px;
}
th {
  text-transform: uppercase;
}
td {
  padding: 10px;
}
tr.disabled {
  color: red;
}
input,
select {
  font-size: 16px;
}

form {
  margin: 20px;
  width: 350px;
}
.field {
  padding: 10px 0px;
}
label {
  width: 140px;
  display: inline-block;
}
button {
  margin-right: 5px;
}
.all-actions {
  margin-bottom: 40px;
}
.btn.save {
  margin: 20px;
  float: right;
}
</style>
